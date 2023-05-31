#include <iostream>
#include <iomanip>
#include <sstream>
#include <string>

// This class provides methods to increment, reset, and retrieve
class Counter {
private:
    int count;

public:
    Counter() : count(0) {}

    void increment() {
        count++;
    }

    void reset() {
        count = 0;
    }

    int getCount() const {
        return count;
    }
};

// Keep track of time
class Clock {
private:
    Counter seconds;
    Counter minutes;
    Counter hours;

public:
    Clock() {}

    void tick() {
        seconds.increment();
        if (seconds.getCount() > 59) {
            minutes.increment();
            seconds.reset();
        }
        if (minutes.getCount() > 59) {
            hours.increment();
            minutes.reset();
        }
        if (hours.getCount() > 23) {
            hours.reset();
            minutes.reset();
            seconds.reset();
        }
    }

    void resetClock() {
        hours.reset();
        minutes.reset();
        seconds.reset();
    }

    //To build the formatted string representation of the time
    //Setfill manipulator ensures that leading zeros are added
    std::string getTime() const {
        std::ostringstream oss; 
        oss << std::setfill('0') << std::setw(2) << hours.getCount() << ":"
            << std::setfill('0') << std::setw(2) << minutes.getCount() << ":"
            << std::setfill('0') << std::setw(2) << seconds.getCount();
        return oss.str();
    }
};

int main() {
    Clock myClock;
    myClock.resetClock();

    for (int i = 0; i < 260; i++) {
        myClock.tick();
        std::cout << myClock.getTime() << std::endl;
    }

    return 0;
}
