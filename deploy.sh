#!/bin/bash

ssh root@$IP <<EOF
echo "PULL FROM GIT!!!"
cd /home
rm -rf News-App
git clone https://github.com/IdokkeI/News-App.git
cd News-App/news-server/news-server
dotnet publish -o /var/www/appNews
cd /home/News-App/news-client
npm install
pm2 restart news-server
pm2 restart news-client
EOF
echo "END!!!"
