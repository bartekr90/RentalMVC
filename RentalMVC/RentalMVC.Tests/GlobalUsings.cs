global using FluentAssertions;
global using Moq;
global using RentalMVC.Domain.Model.Entity;
global using RentalMVC.Domain.Model.Entity.UserEntities;
global using RentalMVC.Infrastructure;
global using RentalMVC.Infrastructure.Repositories;
global using Xunit;
global using static RentalMVC.Tests.SampleData.AddressSample;

//TODO
/*
na teraz: 

zmigrowaæ bazê
  dokoñczyæ schemat polityk.

  przy zak³adaniu konta dodaæ  tabele userdetail i client (trzeba napisaæ akcje i serwisy)
  napisac jakiœ kontroller ?
zrobiæ commita


    trzeba bêdzie podczas tworzenia workera zaczekac az zwróci baza id user i od razu
    tworzyc nowa table w której ustawimy dane workerowe

  Zapytaæ ai o dodatkowe warunki jaki mo¿e zawieraæ polityka

czy jest sposób by po wykonaniu migracji wywo³ac kod który doda elementy do bazy?
napisac zapytanie o seedowaniu bazy na discordzie 
(dla nowego usera z rol¹ adnim, powi¹zan¹ tabel¹ userdetails, i lessor)

klient zobaczy liste pozycvji i po wybrani elementów przesle swoj¹ listê do kontrolera 
i ten przygotuje reserwacje z przekazan¹ list¹, która bêdzie mog³a byæ zatwierdzona 
*/