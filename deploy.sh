#!/bin/bash
echo "Welcome to the club buddy"
ls -l
cd news-server/news-server
dotnet publish -o  root@$server:/home/BackNews
pm2 restart news-server
echo "END!!!"
