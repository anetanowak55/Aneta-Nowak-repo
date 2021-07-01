#ifndef OUTSIDETASK_H_
#define OUTSIDETASK_H_

#include "PrivateTask.h"

using namespace std;

class OutsideTask : public PrivateTask {
public:
    OutsideTask()
    {
    }
    OutsideTask(int time_needed_, int priority_, string name_, string date_)
    {
        time_needed = time_needed_;
        priority = priority_;
        name = name_;
        due_date = date_;
        readDate(date_);
    }
    ~OutsideTask()
    {
    }
};

#endif