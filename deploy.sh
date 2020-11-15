#!/bin/bash
echo "Welcome to the club buddy"
cd news-server
dotnet publish news-server.sln
cd news-server/bin/Debug/netcoreapp3.1/publish
echo "#############!!!!!!"
ls -l
scp -rp ./* root@$server:/var/www/appNews/
echo "END!!!"
