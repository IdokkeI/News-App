#!/bin/bash
echo "Welcome to the club buddy"
scp -r /home/travis/build/IdokkeI/News-App/news-server/news-server/bin/Debug/netcoreapp3.1/* root@$server:/home/BackNews/
pm2 restart news-server
echo "END!!!"
