@echo off

rem *** MySQL
docker run --name mysql-chinook -p 3307:3306 -e "MYSQL_ROOT_PASSWORD=MyPassword!" -d myalenti/chinookdemo
docker run --name mysql-northwind -p 3308:3306 -e "MYSQL_ROOT_PASSWORD=MyPassword!" -d stackupiss/northwind-db:v1

rem *** Postgres
docker run --name postgres-chinook -p 5433:5432 -d battlesable/chinook

rem *** SQL Server
docker run --name mssqlserver-adventureworks -p 1434:1433 -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=MyPassword!" -d chriseaton/adventureworks:latest
