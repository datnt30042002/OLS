// From react and libs
import React from 'react';
import classNames from 'classnames/bind';

// Componenets
import styles from './Dashboard.module.scss';

const cx = classNames.bind(styles);

const Dashboard = () => {
    return (
        <div className={cx('wrapper')}>
            <div className={cx('wrapper-class')}>Dashboard</div>
        </div>
    );
};

export default Dashboard;
