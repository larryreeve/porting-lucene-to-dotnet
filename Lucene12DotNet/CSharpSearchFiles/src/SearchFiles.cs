using System;

using org.apache.lucene.analysis;
using org.apache.lucene.analysis.standard;
using org.apache.lucene.document;
using org.apache.lucene.search;
using org.apache.lucene.queryParser;


namespace JSharpSearchFiles
{
	class SearchFiles
	{
		[STAThread]
		static void Main(string[] args)
		{
			try 
			{
				Searcher searcher = new IndexSearcher("index");
				Analyzer analyzer = new StandardAnalyzer();

				while (true) 
				{
					Console.Write("Query: ");
					string line = Console.ReadLine();

					if (line.Length <= 0)
						break;

					Query query = QueryParser.parse(line, "contents", analyzer);
					Console.WriteLine("Searching for: " + query.toString("contents"));

					Hits hits = searcher.search(query);
					Console.WriteLine(hits.length() + " total matching documents");

					const int HITS_PER_PAGE = 10;
					for (int start = 0; start < hits.length(); start += HITS_PER_PAGE) 
					{
						int end = Math.Min(hits.length(), start + HITS_PER_PAGE);

						for (int i = start; i < end; i++) 
						{
							Document doc = hits.doc(i);
							string path = doc.get("path");
	    
							if (path != null) 
							{
								Console.WriteLine(i + ". " + path);
							} 
							else 
							{
								String url = doc.get("url");

								if (url != null) 
								{
									Console.WriteLine(i + ". " + url);
									Console.WriteLine("   - " + doc.get("title"));
								} 
								else 
								{
									Console.WriteLine(i + ". " + 
										"No path nor URL for this document");
								}
							}
						}

						if (hits.length() > end) 
						{
							Console.Write("more (y/n) ? ");

							line = Console.ReadLine();

							if (line.Length == 0 || line.StartsWith("\n"))
								break;
						}
					}
				}
				searcher.close();
			} 
			catch (Exception e) 
			{
				Console.WriteLine(" caught a " + e.GetType() 
									+ "\n with message: " + e.Message);
			}
		}
	}
}
