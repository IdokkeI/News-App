#!/bin/bash
echo "Welcome to the club buddy"
ls -l
cd news-server/news-server
scp -rp ~/news-server/news-server/bin/Debug/netcoreapp3.1/* root@$server:/home/BackNews/
echo "END!!!"
