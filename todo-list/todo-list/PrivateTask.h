#ifndef PRIVATETASK_H_
#define PRIVATETASK_H_

#include "Task.h"

using namespace std;

class PrivateTask : public Task {
public:
    PrivateTask()
    {
    }
    PrivateTask(int time_needed_, int priority_, string name_, string date_)
    {
		time_needed = time_needed_;
		priority = priority_;
		name = name_;
        due_date = date_;
		readDate(date_);
    }
};

#endif