echo "PULL FROM GIT!!!"
cd /home/News-App
git pull
cd news-server/news-server
dotnet publish -o /var/www/appNews
cd /home/News-App/news-client
npm install
pm2 restart news-server
pm2 restart news-client
echo "END!!!"
