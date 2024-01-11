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

zmigrowa� baz�
  doko�czy� schemat polityk.

  przy zak�adaniu konta doda�  tabele userdetail i client (trzeba napisa� akcje i serwisy)
  napisac jaki� kontroller ?
zrobi� commita


    trzeba b�dzie podczas tworzenia workera zaczekac az zwr�ci baza id user i od razu
    tworzyc nowa table w kt�rej ustawimy dane workerowe

  Zapyta� ai o dodatkowe warunki jaki mo�e zawiera� polityka

czy jest spos�b by po wykonaniu migracji wywo�ac kod kt�ry doda elementy do bazy?
napisac zapytanie o seedowaniu bazy na discordzie 
(dla nowego usera z rol� adnim, powi�zan� tabel� userdetails, i lessor)

klient zobaczy liste pozycvji i po wybrani element�w przesle swoj� list� do kontrolera 
i ten przygotuje reserwacje z przekazan� list�, kt�ra b�dzie mog�a by� zatwierdzona 
*/