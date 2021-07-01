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

/**Funkcja zamienia liniê odczytan¹ z pliku na liczby reprezentuj¹ce geny,
   a nastêpnie tworzy listê genów jednego osobnika. Listê genów osobnika
   dodaje równie¿ do listy list, która reprezentuje ca³¹ populacjê.
   @param populacja wskaŸnik na pierwszego osobnika w populacji
   @param linia linia wczytana z pliku reprezentuj¹ca jednego osobnika
   */
void stworzOsobnika(osobnik *& populacja, string linia);

/**Funkcja dodaje osobnika reprezentowanego przez listê genów do listy ca³ej populacji.
   @param pHead wskaŸnik na pierwszego osobnika w populacji
   @param pChromosom wskaŸnik na pierwszy gen osobnika
   */
void dodajOsobnika(osobnik *& pHead, gen * pChromosom);

/**Funkcja dodaje gen na koniec listy reprezentuj¹cej jednego osobnika.
   @param pHead wskaŸnik na pierwszy gen
   @param liczba wartoœæ do dodania
   */
void dodajGen /*na koniec*/(gen *& pHead, int liczba);

/**Funkcja wypisuj¹ca wszystkie osobniki w populacji.
   @param pHead wskaŸnik na pierwszego osobnika w populacji
   */
void wypiszOsobniki(osobnik* pHead);

/**Funkcja usuwa wszystkie listy zawieraj¹ce dane o populacji.
   @param pHead wskaŸnik na pierwszego osobnika w populacji
   */
void usunPopulacje(osobnik*& pHead);

/**Funkcja usuwa osobnika, tj. listê genów, która go reprezentuje.
   @param pHead wskaŸnik na pierwszy gen
   */
void usunOsobnika(gen*& pHead);

/**Funkcja zlicza osobniki w populacji.
   @param populacja wskaŸnik na pierwszego osobnika w populacji
   @return liczba osobników w populacji
   */
int policzOsobniki(osobnik* populacja);

/**Funkcja zlicza geny, które posiada jeden osobnik.
   @param pHead wskaŸnik na pierwszy gen osobnika
   @return liczba genów osobnika
   */
int policzGeny(gen* pHead);

/**Funkcja tworzy nowe osobniki na podstawie fragmentów osobników ju¿ istniej¹cych.
   @param populacja wskaŸnik na pierwszego osobnika
   @param nowe_osobniki liczba nowych osobników, które trzeba stworzyæ
   */
void rozmnazanie(osobnik*& populacja, int nowe_osobniki);

/**Funkcja losuje liczbê z podanego zakresu.
   @param min najni¿sza liczba jaka mo¿e byæ wylosowana
   @param max najwy¿sza liczba jaka mo¿e byæ wylosowana
   @return wylosowana liczba
   */
int los(int min, int max);

/**Funkcja losuje dwa osobniki z populacji.
   @param n liczba osobników w populacji
   @param pierwszy numer pierwszego wylosowanego osobnika
   @param pierwszy numer drugiego wylosowanego osobnika
   */
void losujOsobniki(int n, int & pierwszy, int & drugi);

/**Funkcja szuka wskaŸnika na osobnika w populacji i znanym numerze.
   @param populacja wskaŸnik na pierwszego osobnika w populacji
   @param numerek numer osobnika do znalezienia
   @return wskaŸnik na szukanego osobnika
   */
osobnik* znajdzOsobnik(osobnik* populacja, int numerek);

/**Funkcja tworzy nowego osobnika na podstawie fragmentów dwóch istniej¹cych osobników.
   @param pPierwszy wskaŸnik na pierwszego ju¿ istniej¹cego osobnika/rodzica
   @param pDrugi wskaŸnik na drugiego ju¿ istniej¹cego osobnika/rodzica
   @param pekniecie_pierwszy miejsce do którego nale¿y skopiowaæ geny osobnika pierwszego
		  i nastêpnie dodaæ je do genów nowego osobnika
   @param pekniecie_drugi miejsce od którego nale¿y skopiowaæ geny osobnika drugiego
		  i nastêpnie dodaæ je do genów nowego osobnika
   @return wskaŸnik na pierwszy gen nowego osobnika
   */
gen* nowyOsobnik(osobnik* pPierwszy, osobnik* pDrugi, int pekniecie_pierwszy, int pekniecie_drugi);

/**Funkcja w zale¿noœci od wartoœci wspó³czynnika dostosowania dla ka¿dego osobnika usuwa go,
   pozostawia bez zmian lub klonuje.
   @param populacja wskaŸnik na pierwszego osobnika w populacji
   @param wsp_wymierania wartoœæ wspó³czynnika dostosowania poni¿ej której nale¿y usun¹æ
		  danego osobnika
   @param wsp_rozmnazania wartoœæ wspó³czynnika dostosowania powy¿ej której nale¿y sklonowaæ
		  danego osobnika
   @return wskaŸnik na pierwszego osobnika w liœcie osobników dostosowanych
   */
osobnik* sprawdzDostosowanie(osobnik* populacja, double wsp_wymierania, double wsp_rozmnazania);

/**Funkcja oblicza wspó³czynnik dostosowania dla danego osobnika.
   @param pHead wskaŸnik na danego osobnika w populacji
   @return wspó³czynnik dostosowania
   */
double obliczDostosowanie(osobnik* pHead);

/**Funkcja zwraca najwiêksz¹ liczbê reprezetuj¹c¹ geny danego osobnika
   @param pHead wskaŸnik na danego osobnika w populacji
   @return najwiêksza liczba reprezetuj¹ca geny danego osobnika
   */
double max(gen* pHead);

/**Funkcja zwraca najmniejsz¹ liczbê reprezetuj¹c¹ geny danego osobnika
   @param pHead wskaŸnik na danego osobnika w populacji
   @return najmniejsza liczba reprezetuj¹ca geny danego osobnika
   */
double min(gen* pHead);

/**Funkcja kopiuje danego osobnika.
   @param pHead wskaŸnik na danego osobnika w populacji
   @return wskaŸnik na pierwszy gen nowego (skopiowanego) osobnika
   */
gen* kopiujOsobnika(osobnik* pHead);

/**Funkcja zapisuje wszystkie osobniki w populacji do strumienia znakowego.
   @param populacja wskaŸnik na pierwszego osobnika w populacji
   @param ss strumieñ znakowy do którego jest zapisywana populacja
   */
void zapiszPopulacje(osobnik* populacja, stringstream& ss);

/**Funkcja pobiera parametry z wiersza poleceñ.
   @param argc liczba parametrów pobranych z wiersza poleceñ
   @param *argv[] tablica zawieraj¹ca parametry pobrane z wiersza poleceñ
   @param iFile œcie¿ka do pliku z danymi wejœciowymi
   @param oFile œcie¿ka do pliku z danymi wyjœciowymi
   @param wsp_wymierania wartoœæ wspó³czynnika dostosowania poni¿ej której nale¿y usun¹æ
		  danego osobnika
   @param wsp_rozmnazania artoœæ wspó³czynnika dostosowania powy¿ej której nale¿y sklonowaæ
		  danego osobnika
   @param pokolenia liczba pokoleñ, które maj¹ zostaæ zasymulowane przez program
   @param nowe_osobniki liczba osobników, które maj¹ powstaæ na drodze rozmna¿ania w
		  ka¿dym pokoleniu
   @return funkcja zwraca wartoœæ prawda lub fa³sz
   */
bool pobierzParametry(int argc, char **argv, string& iFile, string& oFile,
	double& wsp_wymierania, double& wsp_rozmnazania, int& pokolenia, int& nowe_osobniki);

/**Funkcja sprawdza, czy plik jest pusty.
   @param pFile strumieñ plikowy
   @return funkcja zwraca wartoœæ prawda lub fa³sz*/
bool czyPusty(ifstream& pFile);

#endif
