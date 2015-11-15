# Bny.Blog.Backend
A very simple and puristic blog engine which manages your collection of markdown posts and serves them as HTML using a  RESTful API.

####Features

  * Write blog posts in markup language using your favorite editor
  * Grouping articles by Tags
  * Grouping articles  to article series
  * Preview mode for articles which are not ready to publish yet
  * Disqus commenting system integration
  * Syntax highlighting for posting source code

####Setup

Install required dependencies:

Linux & Mono
```
git clone https://github.com/bennygr/Bny.Blog.Backend.git
nuget restore
xbuild
```

Change the settings in bin/Release/etc/bny.bnyconfig to meet your needs:
```
#The title/name of the blog
bny.blog.frontend.title = bny.io ツ★

#The directory to load all md-files from
bny.blog.articleDirectory = /home/bgr/Workspace/Bny.Blog.Articles/

#The port to listen to
bny.blog.service.port = 50119

#The URL template for a quick edit link - uncomment to dissable quick-edit functionality
#{0} - Will be replaced with the articles's filename
bny.blog.quickEditLink = https://github.com/bennygr/bnyArticles/edit/master/{0}

```
Start the service
```
Bny.Blog.Backend.Nancy/bin/Release/Bny.Blog.Backend.Nancy.exe
```

####Usage 

In order to use the helper scripts you should set your destination URL:

```
export BNY_URL=http://localhost:8080
```

######Creating an article
```
./create_article.sh myArticle
```

This will create an empty article with some meta information:
```
<!--
Title:"myArticle",
Date:"2014-05-18T17:55+0200",
Tags:"$TAGS",
PreviewLength:"500",
PreviewCode:"822e0a39-52ab-4fb8-9e8a-823bdefef1d1",
-->
This is the first text line of your new article.
```

Everything between `<!--` and  `-->` is not part of your article but contains some meta informationn like the title, the date, a comma separated list of tags, the amount of preview characters displayed on the main page and a preview code.

Use your preview code to see a preview of your article without publishing it.
`http://localhost:8080//articles/preview/822e0a39-52ab-4fb8-9e8a-823bdefef1d1`

######Publishing an article

Publish your article:
```
./publish_article.sh ./articles/myArticle.md
```

######Changing an article

After chaning an article with your favorite editor you have to call 
`http://$BNY_URL:8080/articles/reload` in order to reload your changes.
