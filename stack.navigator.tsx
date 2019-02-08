import { Icon } from "native-base";
import * as React from 'react';
import { StyleSheet, TouchableOpacity } from 'react-native';
import { StackNavigator } from 'react-navigation';

import { AppRoutes, AppRouteTitles } from './app.routes';
import HomeComponent from './features/home/home.component';
import LoginComponent from './features/login/login.component';
import RegisterComponent from './features/register/register.component';
import TopUpComponent from './features/top-up/top-up.component';
import TransferComponent from './features/transfer/transfer.component';
//import * from  './features/newStuff/transfer.component'

const styles = StyleSheet.create({
    menuIcon: {
        marginLeft: 10
    }
});

// const renderNavigationOptionFor = (route: keyof typeof AppRoutes, navigation: any, showHeader: boolean) => ({
//     title: AppRouteTitles[route],
//     headerLeft: (
//         <TouchableOpacity onPress={() => navigation.openDrawer()} style={styles.menuIcon}>
//             <Icon name="menu"/>
//         </TouchableOpacity>
//     )
// });

const renderNavigationOptionFor = (
    route: keyof typeof AppRoutes,
    navigation: any,
    showHeader: boolean
  ) => {
    if (showHeader)
      return {
        title: AppRouteTitles[route],
        headerLeft: (
          <TouchableOpacity
            onPress={() => navigation.openDrawer()}
            style={styles.menuIcon}
          >
            <Icon name="menu" />
          </TouchableOpacity>
        )
      };
    return {
      header: null
    };
  };

export const stackNavigator = StackNavigator({
    [AppRoutes.home]: {
        screen: HomeComponent,
        navigationOptions: ({ navigation }: { navigation: any}) =>
            renderNavigationOptionFor(AppRoutes.home, navigation, true)
    },
    [AppRoutes.login]: {
        screen: LoginComponent,
        navigationOptions: ({ navigation }: { navigation: any }) =>
            renderNavigationOptionFor(AppRoutes.login, navigation, false)
    },
    [AppRoutes.register]: {
        screen: RegisterComponent,
        navigationOptions: ({ navigation }: { navigation: any }) =>
            renderNavigationOptionFor(AppRoutes.register, navigation,false)
    },
    [AppRoutes.top_up]: {
        screen: TopUpComponent,
        navigationOptions: ({ navigation }: { navigation: any }) =>
            renderNavigationOptionFor(AppRoutes.top_up, navigation, true)
    },
    [AppRoutes.transfer]: {
        screen: TransferComponent,
        navigationOptions: ({ navigation }: { navigation: any }) =>
            renderNavigationOptionFor(AppRoutes.transfer, navigation, true)
    }
    // [AppRoutes.nfl_crimes]: {
    //     screen: NflCrimesComponent,
    //     navigationOptions: ({ navigation }: { navigation: any }) =>
    //         renderNavigationOptionFor(AppRoutes.nfl_crimes, navigation)
    // }
}, {
    initialRouteName: AppRoutes.login
});