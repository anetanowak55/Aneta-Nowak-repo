#ifndef UI_H_
#define UI_H_

#include <iostream>
#include <string>
#include <vector>
#include <memory>
#include <regex>

#include "TaskManager.h"

using namespace std;

class UI {
	TaskManager tm;

	void menu()
	{
		while (1)
		{
			system("cls");
			string command;
			cout << "Wybierz akcje:" << endl;
			cout << "1 Otworz plik z baza zadan" << endl;
			cout << "2 Dodaj nowe zadanie" << endl;
			cout << "3 Usun zadanie" << endl;
			cout << "4 Wyswietl liste zadan" << endl;
			cout << "5 Przygotuj liste zadan do wykonania" << endl;
			cout << "6 Zapisz baze zadan do pliku" << endl;
			cout << "7 Zakoncz program" << endl;
			getline(std::cin, command);
			int command_ = stoi(command);

			switch (command_)
			{
			case 1: loadFile();
				break;
			case 2: try { addTask(); }
				  catch (string e)
				  {
					  cout << e << endl;
					  addTask();
				  }
				  break;
			case 3: deleteTask();
				break;
			case 4: printTasks();
				break;
			case 5: makeList();
				break;
			case 6: saveFile();
				break;
			case 7: return;
				break;
			default: cout << "Niepoprawna komenda. Sprobuj ponownie." << endl;
				system("pause");
				break;
			}
		}
	}
	void loadFile()
	{
		string filename;
		cout << endl << "Podaj sciezke pliku, z ktorego chcesz wczytac baze zadan:" << endl;
		getline(cin, filename);
		
		std::regex reg_file("^(?!.*_).*\.txt$");
		if (not std::regex_match(filename, reg_file))
		{
			cout << "Error: incorrect file name" << endl;
			system("pause");
			return;
		}

		try 
		{
			tm.loadFromFile(filename);
		}
		catch (string e)
		{
			cout<<e<<endl;
			system("pause");
		}
		cout << "Poprawnie wczytano plik." << endl;
		system("pause");
	}
	void addTask()
	{
		cout << endl;
		string name = chooseName();
		category cat = chooseCategory();
		cout  << "Ile czasu potrzeba na wykonanie tego zadania w minutach? ";
		string time;
		getline(cin, time);
		std::regex reg_time("^[1-9][[:digit:]]*$");
		if (not std::regex_match(time, reg_time))
		{
			string s = "Error: incorrect time. Try again";
			throw s;
		}
		int time_i = stoi(time);
		int pr = choosePriority();

		cout << "Do kiedy nalezy wykonac zadanie? Podaj date w formacie dd-mm-rrrr: ";
		string date;
		getline(cin, date);

		std::regex reg_date("^[[:digit:]]{2}\\-[[:digit:]]{2}\\-[[:digit:]]{4}$");
		if (not std::regex_match(date, reg_date))
		{
			string s = "Error: incorrect date. Try again";
			throw s;
		}

		tm.addTask(cat, time_i, pr, name, date);
		cout << "Dodano zadanie." << endl;
		system("pause");
	}
	void deleteTask()
	{
		cout << endl;
		category cat = chooseCategory();
		string name = chooseName();
		if (tm.deleteTask(cat, name))
		{
			cout << "Zadanie zostalo usuniete." << endl;
		}
		else
		{
			cout << "Blad: nie odnaleziono zadania." << endl;
		}

		system("pause");
	}
	void printTasks()
	{
		cout << endl;
		tm.printTaskBase();
		system("pause");
	}
	void makeList()
	{
		cout << endl;
		tm.createTodoList();
		system("pause");
	}
	void saveFile()
	{
		cout << endl;
		string filename;
		cout << endl << "Podaj sciezke pliku .txt, do ktorego chcesz zapisac baze zadan:" << endl;
		getline(cin, filename);

		std::regex reg_file("^(?!.*_).*\.txt$");
		if (not std::regex_match(filename, reg_file))
		{
			cout << "Error: incorrect file name" << endl;
			system("pause");
			return;
		}

		tm.saveToFile(filename);
		cout << "Baza zostala zapisana do pliku." << endl;
		system("pause");
	}
	category chooseCategory()
	{
		cout << "Wybierz kategorie zadania:" << endl;
		cout << "1 Zadanie w domu" << endl;
		cout << "2 Zadanie poza domem" << endl;
		cout << "3 Zadanie w pracy" << endl;
		string command;
		category cat = category::home_task;
		getline(cin, command);
		int command_ = stoi(command);
		
		switch (command_)
		{
		case 1: cat = category::home_task;
			break;
		case 2: cat = category::outside_task;
			break;
		case 3: cat = category::work_task;
			break;
		default: cout << "Niepoprawna kategoria. Sprobuj ponownie." << endl;
			chooseCategory();
			break;
		}
		return cat;
	}
	int choosePriority()
	{
		string pr;
		cout << "Wybierz priorytet dla zadania (0 - najmniejszy, 3 - najwiekszy): ";
		getline(cin, pr);
		int pr_ = stoi(pr);
		if (pr_ > 3 or pr_ < 0)
		{
			cout << "Error: incorrect priority. Try again." << endl;
			choosePriority();
		}
		return pr_;
	}
	string chooseName()
	{
		cout << "Wprowadz nazwe zadania: ";
		string name;
		getline(cin, name);
		return name;
	}
public:
	UI()
	{
		try
		{
			menu();
		}
		catch (...)
		{
			cout << "Undefined error" << endl;
			menu();
		}
	}
	~UI()
	{
	}
};

#endif