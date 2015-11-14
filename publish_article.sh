#!/bin/bash
#------------------------------------------------------------------------
# This is a simple helper script to publish a draft
#------------------------------------------------------------------------

#checking for the BNY_URL enveronment
if [ -z "$BNY_BLOG_URL" ];
then
	echo "Error: BNY_BLOG_URL environment variable is not set"
	exit -1;
fi;

#parsing arguments
if [ -z "$1" ];
then
	echo "file name expected"
	exit -2;
fi;
FILENAME="$1";

#------------------------------------------------------------------------
#publishing article by removing the PreviewCode from the article's header
echo -n "Do you want to publish article $FILENAME? [ y | n ]: " && read YES;
if [ $YES == "y" ]; then
	sed -i '/PreviewCode.*$/d' $FILENAME;
	#refreshing articles
	echo "Refreshing articles... ";
	curl "$BNY_BLOG_URL/articles/reload";
	RETVAL=$?
	if [ $RETVAL -eq 0 ];
	then
		echo
		echo
		echo "-->";
		echo "Article $FILENAME has been published";
	else
		echo
		echo
		echo "-->";
		echo "Error refreshing articles: Curl errorcode $RETVAL";
	fi;
else 
	echo "Article $FILENAME has NOT been published";
fi;

#------------------------------------------------------------------------
#EOF

