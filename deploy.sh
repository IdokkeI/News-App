#!/bin/bash
echo "Welcome to the club buddy"
cd news-server/news-server/bin/Debug/netcoreapp3.1
ls -l
scp -r ./news-server/news-server/bin/Debug/netcoreapp3.1/* root@$server:/home/BackNews/
pm2 restart news-server
echo "END!!!"
