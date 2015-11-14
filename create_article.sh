#!/bin/bash
#------------------------------------------------------------------------
# This is a simple helper script creating an blog article in preview mode
#------------------------------------------------------------------------

#parsing arguments
if [ -z "$1" ];
then
	echo "file name expected"
	exit -1
fi;
FILENAME="$1";

#------------------------------------------------------------------------

#getting article name from  user input
echo -n "Title: " && read TITLE

#------------------------------------------------------------------------

#creating a preview id for the article
PREVIEWCODE=`uuidgen`;

#------------------------------------------------------------------------
#creating the article
if [ ! -f "$FILENAME" ]; 
then
	DATE=`date -Iminutes`;
	touch $FILENAME;
	echo '<!--
Title:"'$TITLE'",
Date:"'$DATE'",
Tags:"$TAGS",
PreviewLength:"500",
PreviewCode:"'$PREVIEWCODE'",
-->
This is the first text line of your new article.' >> $FILENAME;
else
	echo "File for article $FILENAME does allready exist.";
	exit -2;
fi;

#------------------------------------------------------------------------

#show article in editor
if [ -z "$EDITOR" ]; then
	EDITOR="vim";
fi;
$EDITOR $FILENAME;

#------------------------------------------------------------------------
#EOF

