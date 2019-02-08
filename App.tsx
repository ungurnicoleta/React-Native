import * as React from 'react';
import { Dimensions } from 'react-native';
import { DrawerNavigator } from 'react-navigation';

import SideMenuComponent from './side-menu/side-menu.component';
import { stackNavigator } from './stack.navigator';


const App = DrawerNavigator({
    App: {
        screen: stackNavigator
    }
}, {
    contentComponent: SideMenuComponent,
    drawerWidth: Dimensions.get('window').width * 0.8
});

export default App;
