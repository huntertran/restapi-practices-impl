package patterns.sample.services;

import java.util.concurrent.Callable;

public class TimeOutTask implements Callable<String> {

    private int time;

    public TimeOutTask() {
        this.time = 5000;
    }

    /**
     * Init a time out task with time
     * @param time millisecond
     */
    public TimeOutTask(int time) {
        this.time = time;
    }

    @Override
    public String call() throws Exception {
        // replace the below code with your long running operation
        Thread.sleep(time);
        return "Return after sleep 5 seconds";
    }

}
