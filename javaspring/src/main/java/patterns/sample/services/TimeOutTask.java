package patterns.sample.services;

import java.util.concurrent.Callable;

public class TimeOutTask implements Callable<String> {

    @Override
    public String call() throws Exception {
        //replace the below code with your long running operation
        Thread.sleep(5000);
        return "Return after sleep 5 seconds";
    }
    
}
