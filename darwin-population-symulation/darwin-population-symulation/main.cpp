#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <sstream>
#include <random>
#include <chrono>

#include "funkcje.h"
#include "struktury.h"

using namespace std;

int main(int argc, char **argv)
{
	//parametry z wiersza poleceñ
	string iFile = "plik_wejsciowy.txt";
	string oFile = "plik_wyjsciowy.txt";
	double wsp_wymierania = 0.01;
	double wsp_rozmnazania = 0.3;
	int pokolenia = 1;
	int nowe_osobniki = 2;

	//if (pobierzParametry(argc, argv, iFile, oFile, wsp_wymierania, wsp_rozmnazania, pokolenia, nowe_osobniki))
	{

		for (int i = 0; i < pokolenia; i++)
		{
			cout << "--------------------" << endl;
			cout << ">>> POKOLENIE " << i + 1 << " <<<" << endl;
			ifstream plik_wejsciowy(iFile);
			if (czyPusty(plik_wejsciowy))
			{
				plik_wejsciowy.close();
				cout << "Plik wejsciowy jest pusty!" << endl;
				return 0;
			}

			//iFile -> wektor list
			osobnik* populacja = nullptr; //tutaj znajd¹ siê wskaŸniki na osobniki wczytane z pliku
			while (not plik_wejsciowy.eof())
			{
				string linia;
				getline(plik_wejsciowy, linia);
				stworzOsobnika(populacja, linia);
			}
			plik_wejsciowy.close();

			//rozmna¿anie
			rozmnazanie(populacja, nowe_osobniki);
			cout << endl;
			cout << "TO JEST CALA POPULACJA:" << endl;
			wypiszOsobniki(populacja);
			cout << endl;

			//dostosowanie
			osobnik* pDostosowani = sprawdzDostosowanie(populacja, wsp_wymierania, wsp_rozmnazania);
			cout << endl;
			cout << "TO JEST POPULACJA PO UWZGLEDNIENIU DOSTOSOWANIA:" << endl;
			wypiszOsobniki(populacja);
			wypiszOsobniki(pDostosowani);

			//zapisanie do strumienia
			stringstream ss;
			zapiszPopulacje(populacja, ss);
			zapiszPopulacje(pDostosowani, ss);

			//strumieñ -> plik
			ofstream plik_wyjsciowy(oFile);

			if (plik_wyjsciowy.is_open())
				plik_wyjsciowy << ss.rdbuf();
			plik_wyjsciowy.close();

			//zwolnij pamiêæ
			usunPopulacje(populacja);
			usunPopulacje(pDostosowani);

			//zamieñ plik oFile na iFile, aby pêtla mog³a siê ponownie wykonaæ
			iFile = oFile;
		}
	}
	system("pause");
	return 0;
}
