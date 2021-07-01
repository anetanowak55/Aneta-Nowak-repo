#ifndef HOMETASK_H_
#define HOMETASK_H_

#include "PrivateTask.h"

using namespace std;

class HomeTask : public PrivateTask {
public:
    HomeTask()
    {
    }
    HomeTask(int time_needed_, int priority_, string name_, string date_)
    {
        time_needed = time_needed_;
        priority = priority_;
        name = name_;
        due_date = date_;
        readDate(date_);
    }
    ~HomeTask()
    {
    }
};

#endif