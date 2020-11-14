#!/bin/bash
echo "Welcome to the club buddy"
ls -l
cd news-server
ls -l
dotnet build news-server.sln
cd news-server
ls -l
cd bin
ls -l
scp -rp news-server/news-server/bin/Debug/netcoreapp3.1 root@$server:/home/BackNews/
echo "END!!!"
