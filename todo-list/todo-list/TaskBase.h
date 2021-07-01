#ifndef TaskBase_H_
#define TaskBase_H_

#include <vector>

#include "Task.h"
#include "PrivateTask.h"
#include "HomeTask.h"
#include "OutsideTask.h"
#include "WorkTask.h"

using namespace std;

enum class category {
	home_task, outside_task, work_task, todo_list
};

class TaskBase {
protected:
	vector<std::shared_ptr<Task>> home_tasks;
	vector<std::shared_ptr<Task>> outside_tasks;
	vector<std::shared_ptr<Task>> work_tasks;
	vector<std::shared_ptr<Task>> todo_list;
public:
	TaskBase()
	{
	}
	void addTask(category cat, int time_needed_, int priority_, string name_, string date_)
	{
		if (cat == category::home_task)
		{
			home_tasks.push_back(std::make_unique<HomeTask>(time_needed_, priority_, name_, date_));
		}
		else if (cat == category::outside_task)
		{
			outside_tasks.push_back(std::make_unique<OutsideTask>(time_needed_, priority_, name_, date_));
		}
		else if (cat == category::work_task)
		{
			work_tasks.push_back(std::make_unique<WorkTask>(time_needed_, priority_, name_, date_));
		}
		else
		{
			cout << "Error: cannot add task" << endl;
		}
	}
	void addTask(std::shared_ptr<Task> task)
	{
		todo_list.push_back(task);
	}
	bool deleteTask(category cat, string name_)
	{
		if (cat == category::home_task)
		{
			for (auto i = 0; i < home_tasks.size(); i++)
			{
				if (home_tasks[i]->name == name_)
				{
					home_tasks.erase(home_tasks.begin() + i);
					return 1;
				}
			}
			return 0;
		}
		else if (cat == category::outside_task)
		{
			for (auto i = 0; i < outside_tasks.size(); i++)
			{
				if (outside_tasks[i]->name == name_)
				{
					outside_tasks.erase(outside_tasks.begin() + i);
					return 1;
				}
			}
			return 0;
		}
		else if (cat == category::work_task)
		{
			for (auto i = 0; i < work_tasks.size(); i++)
			{
				if (work_tasks[i]->name == name_)
				{
					work_tasks.erase(work_tasks.begin() + i);
					return 1;
				}
			}
			return 0;
		}
	}
	void printTaskBase()
	{
		cout << endl << "   --- Home tasks ---" << endl;
		for (auto const& i : home_tasks)
			i->printTask();
		cout << endl << "   --- Outside tasks ---" << endl;
		for (auto const& i : outside_tasks)
			i->printTask();
		cout << endl << "   --- Work tasks ---" << endl;
		for (auto const& i : work_tasks)
			i->printTask();
		cout << endl;
	}
	void printTodoList()
	{
		for (auto const& i : todo_list)
			i->printTask();
		cout << endl;
	}
	~TaskBase()
	{
	}
};

#endif