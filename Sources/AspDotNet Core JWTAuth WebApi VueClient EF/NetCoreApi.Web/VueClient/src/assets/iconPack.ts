// https://github.com/FortAwesome/vue-fontawesome/blob/master/README.md
// https://blog.logrocket.com/full-guide-to-using-font-awesome-icons-in-vue-js-apps-5574c74d9b2d

import { library } from '@fortawesome/fontawesome-svg-core';
import { FontAwesomeIcon, FontAwesomeLayers, FontAwesomeLayersText } from '@fortawesome/vue-fontawesome';

import { faCog, faSpinner, faCircleNotch, faHome, faListAlt,
         faFileAlt, faInfoCircle, faRedo, faUser, faSignOutAlt } from '@fortawesome/free-solid-svg-icons';

library.add(
    faSpinner,
    faCircleNotch,
    faCog,
    faHome,
    faListAlt,
    faFileAlt,
    faInfoCircle,
    faRedo,
    faUser,
    faSignOutAlt
);

export {library as IconLibrary, FontAwesomeIcon, FontAwesomeLayers, FontAwesomeLayersText};
