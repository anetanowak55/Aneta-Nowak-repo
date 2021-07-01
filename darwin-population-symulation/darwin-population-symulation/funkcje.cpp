#include <iostream>
#include <vector>
#include <string>
#include <iomanip>
#include <random>
#include <chrono>
#include <sstream>

#include "funkcje.h"
#include "struktury.h"

using namespace std;

void stworzOsobnika(osobnik *& populacja, string linia)
{
	vector<double> chromosom; //tutaj zapiszemy liczby z pobranej linii

	stringstream ss; //wyciaganie poszczegolnych liczb ze stringa, ktory zawiera calego jednego osobnika
	ss << linia; //linia z pliku wczytywana do strumienia lancuchowego

	double liczba;
	while (ss >> liczba) chromosom.push_back(liczba); //zapisuje liczby z linii do wektora

	gen * pChromosom = nullptr;

	for (int i = 0; i < chromosom.size(); i++)
		dodajGen(pChromosom, chromosom[i]);

	dodajOsobnika(populacja, pChromosom);
}

void dodajOsobnika(osobnik *& pHead, gen * pChromosom)
{
	if (not pHead) // lista pusta
	{
		pHead = new osobnik{ pChromosom, nullptr };
	}
	else // lista niepusta
	{
		auto p = pHead;

		while (p->pNext)
			p = p->pNext;

		// w tym miejscu p wskazuje na ostatni element listy
		p->pNext = new osobnik{ pChromosom, nullptr };
	}
}

void dodajGen /*na koniec*/(gen *& pHead, int liczba)
{
	if (not pHead) // lista pusta
	{
		pHead = new gen{ liczba, nullptr };
	}
	else // lista niepusta
	{
		auto p = pHead;

		while (p->pNext)
			p = p->pNext;

		// w tym miejsce p wskazuje na ostatni element listy
		p->pNext = new gen{ liczba, nullptr };
	}
}

void wypiszOsobniki(osobnik* pHead)
{
	while (pHead)
	{
		gen* wskaznikNaElement = pHead->pChromosom; //inaczej pHead->wartosc byloby modyfikowane
		while (wskaznikNaElement)
		{
			cout << wskaznikNaElement->wartosc << " ";
			wskaznikNaElement = wskaznikNaElement->pNext; // przesuwamy sie na nastepny element
		}
		pHead = pHead->pNext;
		cout << endl;
	}
}

void usunPopulacje(osobnik*& pHead)
{
	if (pHead)
	{
		usunOsobnika(pHead->pChromosom);
		usunPopulacje(pHead->pNext);
		delete pHead;
		pHead = nullptr;
	}
}

void usunOsobnika(gen*& pHead)
{
	if (pHead)
	{
		usunOsobnika(pHead->pNext);
		delete pHead;
		pHead = nullptr;
	}
}

void rozmnazanie(osobnik*& populacja, int nowe_osobniki)
{
	int osobniki = policzOsobniki(populacja);
	cout << "tyle jest osobnikow w populacji: " << osobniki << endl;
	cout << endl;

	for (int i = 0; i < nowe_osobniki; i++)
	{
		int pierwszy, drugi;
		losujOsobniki(osobniki - 1, pierwszy, drugi);
		cout << "do rozmnazania wylosowano pare: " << pierwszy << " i " << drugi << endl;

		osobnik* pPierwszy = znajdzOsobnik(populacja, pierwszy);
		int geny_pierwszy = policzGeny(pPierwszy->pChromosom);
		int pekniecie_pierwszy = los(0, geny_pierwszy);

		osobnik* pDrugi = znajdzOsobnik(populacja, drugi);
		int geny_drugi = policzGeny(pDrugi->pChromosom);
		int pekniecie_drugi = los(0, geny_drugi);

		gen* pNowy = nowyOsobnik(pPierwszy, pDrugi, pekniecie_pierwszy, pekniecie_drugi);
		dodajOsobnika(populacja, pNowy);

	}
}

int policzOsobniki(osobnik* populacja)
{
	int licznik = 0;
	auto p = populacja;
	while (p)
	{
		licznik++;
		p = p->pNext;
	}
	return licznik;
}

int policzGeny(gen* pHead)
{
	int licznik = 0;
	auto p = pHead;
	while (p)
	{
		licznik++;
		p = p->pNext;
	}
	return licznik;
}

int los(int min, int max)
{
    // silnik losowy jest statyczny, zeby nie byl tworzony nowy i inicjalizowany w kazdym wywolaniu funkcji
	static std::default_random_engine silnik (std::chrono::system_clock::now().time_since_epoch().count()); 
	
	std::uniform_int_distribution<int> rozklad(min, max);

	return rozklad(silnik);
}

void losujOsobniki(int n, int & pierwszy, int & drugi)
{
	pierwszy = los(0, n);
	drugi = los(0, n);

	if (pierwszy == drugi) losujOsobniki(n, pierwszy, drugi);
}

osobnik* znajdzOsobnik(osobnik* populacja, int numerek)
{
	auto p = populacja;
	for (int i = 0; i < numerek; i++)
		p = p->pNext;
	return p;
}

gen* nowyOsobnik(osobnik* pPierwszy, osobnik* pDrugi, int pekniecie_pierwszy, int pekniecie_drugi)
{
	gen* pNowy = nullptr;

	auto pp = pPierwszy->pChromosom;
	for (int i = 0; i < pekniecie_pierwszy; i++)
	{
		dodajGen(pNowy, pp->wartosc);
		pp = pp->pNext;
	}

	auto pd = pDrugi->pChromosom;
	for (int i = 0; i < pekniecie_drugi; i++)
		pd = pd->pNext;

	while (pd)
	{
		dodajGen(pNowy, pd->wartosc);
		pd = pd->pNext;
	}
	return pNowy;
}

osobnik* sprawdzDostosowanie(osobnik* populacja, double wsp_wymierania, double wsp_rozmnazania)
{
	osobnik* pDostosowani = nullptr;
	while (populacja)
	{
		double dostosowanie = obliczDostosowanie(populacja);
		cout << "dostosowanie osobnika to: " << dostosowanie;
		if (dostosowanie <= wsp_wymierania)
		{
			usunOsobnika(populacja->pChromosom);
			cout << ", zostal usuniety" << endl;
		}
		else if (dostosowanie >= wsp_rozmnazania)
		{
			gen* pNowy = kopiujOsobnika(populacja);
			dodajOsobnika(pDostosowani, pNowy);
			cout << ", zostal sklonowany" << endl;
		}
		else
			cout << endl;
		populacja = populacja->pNext;
	}
	return pDostosowani;
}

double obliczDostosowanie(osobnik* pHead)
{
	double wspolczynnik;

	if (not pHead->pChromosom or not pHead->pChromosom->pNext) //lista jest pusta lub ma jeden element
		wspolczynnik = 0;
	else
		wspolczynnik = min(pHead->pChromosom) / max(pHead->pChromosom);

	return wspolczynnik;
}

double max(gen* pHead)
{
	double max = pHead->wartosc;
	pHead = pHead->pNext;
	while (pHead)
	{
		if (pHead->wartosc > max)
			max = pHead->wartosc;
		pHead = pHead->pNext;
	}
	return max;
}

double min(gen* pHead)
{
	double min = pHead->wartosc;
	pHead = pHead->pNext;
	while (pHead)
	{
		if (pHead->wartosc < min)
			min = pHead->wartosc;
		pHead = pHead->pNext;
	}
	return min;
}

gen* kopiujOsobnika(osobnik* pHead)
{
	gen* pNowy = nullptr;
	auto p = pHead->pChromosom;
	while (p)
	{
		int wartosc;
		wartosc = p->wartosc;
		dodajGen(pNowy, wartosc);
		p = p->pNext;
	}
	return pNowy;
}

void zapiszPopulacje(osobnik* populacja, stringstream& ss)
{
	if (populacja)
	{
		if (populacja->pChromosom)
		{
			auto p = populacja->pChromosom;
			while (p)
			{
				ss << p->wartosc << " ";
				p = p->pNext;
			}
			ss << endl;
		}
		zapiszPopulacje(populacja->pNext, ss);
	}
}

bool pobierzParametry(int argc, char **argv, string& iFile, string& oFile, double& wsp_wymierania, double& wsp_rozmnazania, int& pokolenia, int& nowe_osobniki)
{
	if (argc < 13)
	{
		cout << "Podano nieprawidlowe parametry. Zbyt malo parametrow." << endl;
		cout << "Sprobuj ponownie stosujac nastepujace przelaczniki:" << endl;
		cout << "-i <tutaj zamiesc sciezke do pliku z danymi wejsciowymi>" << endl;
		cout << "-o <tutaj zamiesc sciezke do pliku z danymi wyjsciowymi>" << endl;
		cout << "-w <tutaj podaj wspolczynnik wymierania, musi to byc liczba z przedzialu <0, 1> >" << endl;
		cout << "-r <tutaj podaj wspolczynnik rozmnazania, musi to byc liczba z przedzialu <0, 1> >" << endl;
		cout << "-p <tutaj podaj liczbe pokolen, musi to byc liczba naturalna>" << endl;
		cout << "-k <tutaj podaj liczbe osobnikow ktore powstana w wyniku rozmnazania w kazdym pokoleniu, musi to byc liczba naturalna>" << endl;
		return false;
	}
	else if (argc > 13)
	{
		cout << "Podano nieprawidlowe parametry. Zbyt duzo parametrow." << endl;
		cout << "Sprobuj ponownie stosujac nastepujace przelaczniki:" << endl;
		cout << "-i <tutaj zamiesc sciezke do pliku z danymi wejsciowymi>" << endl;
		cout << "-o <tutaj zamiesc sciezke do pliku z danymi wyjsciowymi>" << endl;
		cout << "-w <tutaj podaj wspolczynnik wymierania, musi to byc liczba z przedzialu <0, 1> >" << endl;
		cout << "-r <tutaj podaj wspolczynnik rozmnazania, musi to byc liczba z przedzialu <0, 1> >" << endl;
		cout << "-p <tutaj podaj liczbe pokolen, musi to byc liczba naturalna>" << endl;
		cout << "-k <tutaj podaj liczbe osobnikow ktore powstana w wyniku rozmnazania w kazdym pokoleniu, musi to byc liczba naturalna>" << endl;
		return false;
	}
	else
	{
		for (int i = 0; i < argc; i++)
		{
			string parametr = argv[i];
			if (parametr == "-i")
				iFile = argv[++i];
			else if (parametr == "-o")
				oFile = argv[++i];
			else if (parametr == "-w")
				wsp_wymierania = atoi(argv[++i]);
			else if (parametr == "-r")
				wsp_rozmnazania = atoi(argv[++i]);
			else if (parametr == "-p")
				pokolenia = atoi(argv[++i]);
			else if (parametr == "-k")
				nowe_osobniki = atoi(argv[++i]);
		}
		return true;
	}
}

bool czyPusty(ifstream& pFile)
{
	return pFile.peek() == ifstream::traits_type::eof();
}
