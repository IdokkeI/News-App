#!/bin/bash
echo "Welcome to the club buddy"
cd news-client
npm i
scp -rp ./* root@$server:/home/FrontNews/
cd..
cd news-server
dotnet publish news-server.sln
cd news-server/bin/Debug/netcoreapp3.1/publish
echo "#############!!!!!!"
scp -rp ./* root@$server:/var/www/appNews/
cd /news-client
ls -l
ssh root@$server <<EOF
 pm2 restart news-server
 pm2 restart news-client
EOF
echo "END!!!"
