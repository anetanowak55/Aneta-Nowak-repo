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

/** wêze³ drzewa poszukiwañ binarnych */
struct wezel
{
	gen * wartosc;     ///< wartoœæ przechowywana w wêŸle   
	wezel * pLewy,   ///< wskaŸnik na lewy potomek
		*pPrawy;  ///< wskaŸnik na prawy potemek
};

#endif
