// libs
import React from 'react';
import classNames from 'classnames/bind';

// layouts
import styles from './Sidebar.module.scss';

const cx = classNames.bind(styles);

const Sidebar = () => {
    return (
        <aside className={cx('wrapper')}>
            <h2>Side bar</h2>
        </aside>
    );
};

export default Sidebar;
