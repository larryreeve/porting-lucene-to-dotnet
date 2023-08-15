cd ..\..\..\javacc-3.0\bin

erase ..\..\Lucene12DotNet\LuceneLibrary\src\org\apache\lucene\analysis\standard\TokenMgrError.java
erase ..\..\Lucene12DotNet\LuceneLibrary\src\org\apache\lucene\analysis\standard\Token.java
erase ..\..\Lucene12DotNet\LuceneLibrary\src\org\apache\lucene\analysis\standard\CharStream.java
erase ..\..\Lucene12DotNet\LuceneLibrary\src\org\apache\lucene\analysis\standard\ParseException.java
call javacc -OUTPUT_DIRECTORY:../../Lucene12DotNet/LuceneLibrary/src/org/apache/lucene/analysis/standard ../../Lucene12DotNet/LuceneLibrary/src/org/apache/lucene/analysis/standard/StandardTokenizer.jj

erase ..\..\Lucene12DotNet\LuceneLibrary\src\org\apache\lucene\queryParser\TokenMgrError.java
erase ..\..\Lucene12DotNet\LuceneLibrary\src\org\apache\lucene\queryParser\Token.java
erase ..\..\Lucene12DotNet\LuceneLibrary\src\org\apache\lucene\queryParser\CharStream.java
erase ..\..\Lucene12DotNet\LuceneLibrary\src\org\apache\lucene\queryParser\ParseException.java

call javacc -OUTPUT_DIRECTORY:../../Lucene12DotNet/LuceneLibrary/src/org/apache/lucene/queryParser ../../Lucene12DotNet/LuceneLibrary/src/org/apache/lucene/queryParser/QueryParser.jj

cd ..\..\Lucene12DotNet\LuceneLibrary\JavaCCGenerator
