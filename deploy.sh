#!/bin/bash
echo "Welcome to the club buddy"
cd /home/travis/build/IdokkeI/News-App/news-server/news-server/bin/Debug/netcoreapp3.1
ls -l
scp -rp /home/travis/build/IdokkeI/News-App/news-server/news-server/bin/Debug/netcoreapp3.1 root@$server:/home/BackNews/
echo "END!!!"
