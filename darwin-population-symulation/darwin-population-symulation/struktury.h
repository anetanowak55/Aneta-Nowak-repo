#ifndef STRUKTURY_H
#define STRUKTURY_H

#include <iostream> 

/** Element listy jednokierunkowej zawierajacej geny jednego osobnika*/
struct gen
{
	int wartosc;  ///< wartosc genu
	gen * pNext;  ///< nastepny gen w chromosomie
};

/** Element listy jednokierunkowej zawierajacej wskazniki osobniki*/
struct osobnik
{
	gen * pChromosom; ///< adres chromosomu zbudowanego z listy genow
	osobnik * pNext;  ///< nastepny osobnik w liscie jednokierunkowej osobnikow
};

/** w�ze� drzewa poszukiwa� binarnych */
struct wezel
{
	gen * wartosc;     ///< warto�� przechowywana w w�le   
	wezel * pLewy,   ///< wska�nik na lewy potomek
		*pPrawy;  ///< wska�nik na prawy potemek
};

#endif
