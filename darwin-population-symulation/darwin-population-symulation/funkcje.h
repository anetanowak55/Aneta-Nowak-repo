#ifndef FUNKCJE_H
#define FUNKCJE_H

#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <sstream>
#include <random>
#include <chrono>

#include "struktury.h" 

using namespace std;

/**Funkcja zamienia lini� odczytan� z pliku na liczby reprezentuj�ce geny,
   a nast�pnie tworzy list� gen�w jednego osobnika. List� gen�w osobnika
   dodaje r�wnie� do listy list, kt�ra reprezentuje ca�� populacj�.
   @param populacja wska�nik na pierwszego osobnika w populacji
   @param linia linia wczytana z pliku reprezentuj�ca jednego osobnika
   */
void stworzOsobnika(osobnik *& populacja, string linia);

/**Funkcja dodaje osobnika reprezentowanego przez list� gen�w do listy ca�ej populacji.
   @param pHead wska�nik na pierwszego osobnika w populacji
   @param pChromosom wska�nik na pierwszy gen osobnika
   */
void dodajOsobnika(osobnik *& pHead, gen * pChromosom);

/**Funkcja dodaje gen na koniec listy reprezentuj�cej jednego osobnika.
   @param pHead wska�nik na pierwszy gen
   @param liczba warto�� do dodania
   */
void dodajGen /*na koniec*/(gen *& pHead, int liczba);

/**Funkcja wypisuj�ca wszystkie osobniki w populacji.
   @param pHead wska�nik na pierwszego osobnika w populacji
   */
void wypiszOsobniki(osobnik* pHead);

/**Funkcja usuwa wszystkie listy zawieraj�ce dane o populacji.
   @param pHead wska�nik na pierwszego osobnika w populacji
   */
void usunPopulacje(osobnik*& pHead);

/**Funkcja usuwa osobnika, tj. list� gen�w, kt�ra go reprezentuje.
   @param pHead wska�nik na pierwszy gen
   */
void usunOsobnika(gen*& pHead);

/**Funkcja zlicza osobniki w populacji.
   @param populacja wska�nik na pierwszego osobnika w populacji
   @return liczba osobnik�w w populacji
   */
int policzOsobniki(osobnik* populacja);

/**Funkcja zlicza geny, kt�re posiada jeden osobnik.
   @param pHead wska�nik na pierwszy gen osobnika
   @return liczba gen�w osobnika
   */
int policzGeny(gen* pHead);

/**Funkcja tworzy nowe osobniki na podstawie fragment�w osobnik�w ju� istniej�cych.
   @param populacja wska�nik na pierwszego osobnika
   @param nowe_osobniki liczba nowych osobnik�w, kt�re trzeba stworzy�
   */
void rozmnazanie(osobnik*& populacja, int nowe_osobniki);

/**Funkcja losuje liczb� z podanego zakresu.
   @param min najni�sza liczba jaka mo�e by� wylosowana
   @param max najwy�sza liczba jaka mo�e by� wylosowana
   @return wylosowana liczba
   */
int los(int min, int max);

/**Funkcja losuje dwa osobniki z populacji.
   @param n liczba osobnik�w w populacji
   @param pierwszy numer pierwszego wylosowanego osobnika
   @param pierwszy numer drugiego wylosowanego osobnika
   */
void losujOsobniki(int n, int & pierwszy, int & drugi);

/**Funkcja szuka wska�nika na osobnika w populacji i znanym numerze.
   @param populacja wska�nik na pierwszego osobnika w populacji
   @param numerek numer osobnika do znalezienia
   @return wska�nik na szukanego osobnika
   */
osobnik* znajdzOsobnik(osobnik* populacja, int numerek);

/**Funkcja tworzy nowego osobnika na podstawie fragment�w dw�ch istniej�cych osobnik�w.
   @param pPierwszy wska�nik na pierwszego ju� istniej�cego osobnika/rodzica
   @param pDrugi wska�nik na drugiego ju� istniej�cego osobnika/rodzica
   @param pekniecie_pierwszy miejsce do kt�rego nale�y skopiowa� geny osobnika pierwszego
		  i nast�pnie doda� je do gen�w nowego osobnika
   @param pekniecie_drugi miejsce od kt�rego nale�y skopiowa� geny osobnika drugiego
		  i nast�pnie doda� je do gen�w nowego osobnika
   @return wska�nik na pierwszy gen nowego osobnika
   */
gen* nowyOsobnik(osobnik* pPierwszy, osobnik* pDrugi, int pekniecie_pierwszy, int pekniecie_drugi);

/**Funkcja w zale�no�ci od warto�ci wsp�czynnika dostosowania dla ka�dego osobnika usuwa go,
   pozostawia bez zmian lub klonuje.
   @param populacja wska�nik na pierwszego osobnika w populacji
   @param wsp_wymierania warto�� wsp�czynnika dostosowania poni�ej kt�rej nale�y usun��
		  danego osobnika
   @param wsp_rozmnazania warto�� wsp�czynnika dostosowania powy�ej kt�rej nale�y sklonowa�
		  danego osobnika
   @return wska�nik na pierwszego osobnika w li�cie osobnik�w dostosowanych
   */
osobnik* sprawdzDostosowanie(osobnik* populacja, double wsp_wymierania, double wsp_rozmnazania);

/**Funkcja oblicza wsp�czynnik dostosowania dla danego osobnika.
   @param pHead wska�nik na danego osobnika w populacji
   @return wsp�czynnik dostosowania
   */
double obliczDostosowanie(osobnik* pHead);

/**Funkcja zwraca najwi�ksz� liczb� reprezetuj�c� geny danego osobnika
   @param pHead wska�nik na danego osobnika w populacji
   @return najwi�ksza liczba reprezetuj�ca geny danego osobnika
   */
double max(gen* pHead);

/**Funkcja zwraca najmniejsz� liczb� reprezetuj�c� geny danego osobnika
   @param pHead wska�nik na danego osobnika w populacji
   @return najmniejsza liczba reprezetuj�ca geny danego osobnika
   */
double min(gen* pHead);

/**Funkcja kopiuje danego osobnika.
   @param pHead wska�nik na danego osobnika w populacji
   @return wska�nik na pierwszy gen nowego (skopiowanego) osobnika
   */
gen* kopiujOsobnika(osobnik* pHead);

/**Funkcja zapisuje wszystkie osobniki w populacji do strumienia znakowego.
   @param populacja wska�nik na pierwszego osobnika w populacji
   @param ss strumie� znakowy do kt�rego jest zapisywana populacja
   */
void zapiszPopulacje(osobnik* populacja, stringstream& ss);

/**Funkcja pobiera parametry z wiersza polece�.
   @param argc liczba parametr�w pobranych z wiersza polece�
   @param *argv[] tablica zawieraj�ca parametry pobrane z wiersza polece�
   @param iFile �cie�ka do pliku z danymi wej�ciowymi
   @param oFile �cie�ka do pliku z danymi wyj�ciowymi
   @param wsp_wymierania warto�� wsp�czynnika dostosowania poni�ej kt�rej nale�y usun��
		  danego osobnika
   @param wsp_rozmnazania arto�� wsp�czynnika dostosowania powy�ej kt�rej nale�y sklonowa�
		  danego osobnika
   @param pokolenia liczba pokole�, kt�re maj� zosta� zasymulowane przez program
   @param nowe_osobniki liczba osobnik�w, kt�re maj� powsta� na drodze rozmna�ania w
		  ka�dym pokoleniu
   @return funkcja zwraca warto�� prawda lub fa�sz
   */
bool pobierzParametry(int argc, char **argv, string& iFile, string& oFile,
	double& wsp_wymierania, double& wsp_rozmnazania, int& pokolenia, int& nowe_osobniki);

/**Funkcja sprawdza, czy plik jest pusty.
   @param pFile strumie� plikowy
   @return funkcja zwraca warto�� prawda lub fa�sz*/
bool czyPusty(ifstream& pFile);

#endif
