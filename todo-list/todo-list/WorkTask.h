#ifndef WORKTASK_H_
#define WORKTASK_H_

#include "PrivateTask.h"

using namespace std;

class WorkTask : public Task {
public:
    WorkTask()
    {
    }
    WorkTask(int time_needed_, int priority_, string name_, string date_)
    {
        time_needed = time_needed_;
        priority = priority_;
        name = name_;
        due_date = date_;
        readDate(date_);
    }
    ~WorkTask()
    {
    }
};

#endif