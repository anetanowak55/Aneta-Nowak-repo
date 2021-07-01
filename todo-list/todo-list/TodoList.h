#ifndef TODOLIST_H_
#define TODOLIST_H_

#include <iostream>
#include <string>
#include <vector>
#include <memory>

#include "TaskBase.h"

using namespace std;

class TodoList : public TaskBase {
public:
	TodoList()
	{
	}
	void printMenu(int &time_available, int &command)
	{
		cout << "Jaka liste zadan chcesz stworzyc?" << endl;
		cout << "1 Zadanie w domu" << endl;
		cout << "2 Zadanie poza domem" << endl;
		cout << "3 Zadanie w pracy" << endl << endl;
		cout << "Wybierz odpowiedni numer: ";
		cin >> command;
		cout << "Podaj ilosc wolnego czasu w minutach: ";
		cin >> time_available;
		cout << endl;
	}
	void makeList(const vector<std::shared_ptr<Task>>& tasks, int time_available)
	{
		for (auto const& i : tasks)
		{
			if (time_available > 0 && i->priority == 3)
			{
				if (time_available >= i->time_needed)
				{
					addTask(i);
					time_available -= i->time_needed;
				}
			}
			if (time_available > 0 && i->priority == 2)
			{
				if (time_available >= i->time_needed)
				{
					addTask(i);
					time_available -= i->time_needed;
				}
			}
			if (time_available > 0 && i->priority<2)
			{
				if (time_available >= i->time_needed)
				{
					addTask(i);
					time_available -= i->time_needed;
				}
			}
		}
		cout << "Your to-do list: " << endl;
		printTodoList();
	}
	~TodoList()
	{
	}
};

#endif
