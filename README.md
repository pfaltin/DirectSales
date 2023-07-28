# DirectSales
# Web CMS za upravljanje narudžbama izravne prodaje

Ovo je jednostavan sustav za upravljanje sadržajem (CMS) koji vam omogućuje upravljanje narudžbama izravne prodaje. Izrađen je pomoću programskog jezika C# i web okvira ASP.NET, s backend bazom podataka pokretanom pomoću Microsoft SQL Servera 2019 koji se pokreće u Docker kontejneru.

## Zašto koristiti ovaj projekt?

Ovaj projekt je koristan ako trebate osnovni CMS za upravljanje narudžbama izravne prodaje. Pruža jednostavno sučelje za dodavanje, uređivanje i brisanje narudžbi, kao i pregled izvješća i statistika. 


## Kako početi

Da biste započeli s ovim projektom, trebat će vam sljedeći softver:

- Visual Studio 2019 ili noviji (za razvoj)
- Docker Desktop (za pokretanje SQL Server kontejnera)
- Web preglednik (za pristup CMS-u)

Koraci za pokretanje projekta:

- Klonirajte projekt s GitHuba na svoje lokalno računalo.
- Otvorite datoteku rješenja (`DirectSalesCMS.sln`) u programu Visual Studio.
- Build rješenja da biste obnovili pakete i kompilirali kod.
- Otvorite terminal.
- Pokrenite sljedeću naredbu da biste pokrenuli SQL Server kontejner:
	docker pull mcr.microsoft.com/mssql/server:2019-latest
	docker run -e "MSSQL_SA_PASSWORD= YourStrongPassword123" -e "ACCEPT_EULA=Y" -p 1433:1433 --name sql2 --hostname sql2 -d  mcr.microsoft.com/mssql/server:2019-latest
	docker ps -a


- Kada kontejner radi, otvorite neki SQL Server alat i povežite se s poslužiteljem `localhost,1433` koristeći pristupne podatke koje ste postavili u predhodnom koraku.
- CMS se trebao otvoriti u vašem zadanim web pregledniku. Možete se prijaviti koristeći korisničko ime `admin` i lozinku `password`.

Napomena: Morat ćete promijeniti "connectin string" u datoteci `appsettings.json` u skladu sa Vašim postavkama sustava.

## Pomoć

Ako vam treba pomoć s ovim projektom, rješanje možete potražit direktno od autora putem posta na GitHub/Issues ili putem epošte.
