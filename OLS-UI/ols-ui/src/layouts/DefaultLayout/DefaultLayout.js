// libs
import React from 'react';
import classNames from 'classnames/bind';
import PropTypes from 'prop-types';

// components
import styles from './DefaultLayout.module.scss';
import Header from '~/layouts/components/Header';
import Navbar from '~/layouts/components/Navbar';

const cx = classNames.bind(styles);

const DefaultLayout = ({ children }) => {
    return (
        <div className={cx('wrapper')}>
            <Header />
            <Navbar />
            <div className={cx('container')}>
                <div className={cx('content')}>{children}</div>
            </div>
        </div>
    );
};

DefaultLayout.propTypes = {
    children: PropTypes.node.isRequired,
};

export default DefaultLayout;
