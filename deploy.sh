#!/bin/bash
echo "Welcome to the club buddy"
cd news-server
dotnet publish news-server.sln
cd news-server/bin/Debug/netcoreapp3.1/publish
echo "#############!!!!!!"
scp -rp ./* root@$server:/var/www/appNews/
scp -rp /news-client/* root@$server:/home/FrontNews/
ssh root@$IP <<EOF
 npm i
 pm2 restart news-server
 pm2 restart news-client
EOF

echo "END!!!"
