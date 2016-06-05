i="0"


while [ $i -lt 1000 ]
do
./StringGenerator.exe "You (are|aren't|killed|marked|) a (black|green|yellow|beige|purple|pink) young great (man|woman)" TestFile.txt
i=$[$i+1]
done
