package com.none.helloworld;


public class InnerClassTest {

    public int aField = 42;

    public static class InnerStaticClass {

        public InnerStaticClass(String msg) {
            System.out.println(msg);
        }
        
    }



    private class InnerNonStaticClass {

        private int nonUsableField = 101;

    }


}