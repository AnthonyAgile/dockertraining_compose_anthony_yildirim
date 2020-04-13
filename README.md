<h2>dockertraining_compose_anthony_yildirim</h2>
<pre>
##Create Docker DB

docker pull mysql
docker volume create anthony_volume
docker run --name database_container -e MYSQL_RANDOM_ROOT_PASSWORD=yes -e MYSQL_DATABASE=anthonydb -e MYSQL_USER=anthony -e MYSQL_PASSWORD=anthony -v anthony_volume:/var/lib/mysql -p 3018:3306 -d mysql

##ONLY THE FIRST TIME: From docker console over dblocal instance, create table the first time and add data
##mysql -u anthony -p
##anthony
##use anthonydb
##CREATE TABLE Stocks(  Id INT unsigned NOT NULL AUTO_INCREMENT,  Symbol VARCHAR(4) NOT NULL,  Description VARCHAR(100) NULL,  PRIMARY KEY (id),  UNIQUE KEY unique_email (Symbol) );
##INSERT INTO Stocks ( Symbol, Description) VALUES( 'FB', 'Facebook' ),( 'AAPL', 'Apple'),( 'AMZN', 'Amazon'),( 'NFLX', 'Netflix' ),( 'GOOG', 'Google Alphabet' );
##select * from Stocks;

docker stop database_container 
docker rm database_container 
################################
##Visual Studio dockertraining_compose_anthony_yildirim
##Compile Visual Studio before next command lines

cd C:\code\dockertraining_compose_anthony_yildirim\dockertraining_compose_anthony_yildirim\
dotnet tool install --global dotnet-ef --version 3.1.3
dotnet-ef migrations add Initial

docker build -f "C:\code\dockertraining_compose_anthony_yildirim\dockertraining_compose_anthony_yildirim\Dockerfile" --force-rm -t anthony_image "C:\code\dockertraining_compose_anthony_yildirim"
docker-compose -f "C:\code\dockertraining_compose_anthony_yildirim\docker-compose.yml" -p docker_compose_anthony_yildirim --no-ansi up -d --no-build --force-recreate --remove-orphans
#launch browser and enjoy
start http://localhost:8091/api/stock/1
</pre>
<IMG SRC='https://github.com/AnthonyAgile/dockertraining_compose_anthony_yildirim/blob/master/COMPOSE_AY.png' />
