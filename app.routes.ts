export enum AppRoutes {
    home = 'home',
    login = 'login',
    register = 'register',
    top_up = 'top_up',
    transfer = 'transfer',
    // TODO: remove it
    //nfl_crimes = 'nfl_crimes',
    //newStuff = 'newStuff'
}

export const AppRouteTitles = {
    [AppRoutes.home]: 'Home',
    [AppRoutes.login]: 'Login',
    [AppRoutes.register]: 'Register',
    [AppRoutes.top_up]: 'Top Up Account',
    [AppRoutes.transfer]: 'Transfer Money to an Account',
    // TODO: remove this
    //[AppRoutes.nfl_crimes]: 'NFL DUI Infractions',
    //[AppRoutes.newStuff]: 'newState'
};
