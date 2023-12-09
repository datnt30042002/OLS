// libs
import React from 'react';
import classNames from 'classnames/bind';
import PropTypes from 'prop-types';

// components
import styles from './DefaultLayout.module.scss';
import Header from '~/layouts/components/Header';
import Navbar from '~/layouts/components/Navbar';
import Footer from '~/layouts/components/Footer';

const cx = classNames.bind(styles);

// Nhận children từ App.js
const DefaultLayout = ({ children }) => {
    return (
        <div className={cx('wrapper')}>
            <Header />
            <Navbar />
            <div className={cx('container')}>
                <div className={cx('content')}>
                    {/* <h1>back</h1> */}
                    {children}
                </div>
            </div>
            <Footer />
        </div>
    );
};

DefaultLayout.propTypes = {
    children: PropTypes.node.isRequired,
};

export default DefaultLayout;
