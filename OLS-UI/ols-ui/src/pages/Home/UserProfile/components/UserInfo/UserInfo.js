// from react and libs
import React from 'react';
import axios from 'axios';
import classNames from 'classnames/bind';
import { useState, useEffect } from 'react';

// components
import styles from './UserInfo.module.scss';
import Image from '~/components/Image';

const cx = classNames.bind(styles);

const UserInfo = () => {
    return (
        <div className={cx('wrapper')}>
            <div className={cx('user-info')}>
                <h1 className={cx('user-info__title')}>Personal details</h1>
                <Image
                    src={'https://avatars.githubusercontent.com/u/108357953?v=4'}
                    className={cx('user-info__avatar')}
                />
                <h1 className={cx('user-info__full-name')}>Full name</h1>
                <br />
                <div className={cx('user-info__update')}>
                    <a href="#" className={cx('user-info__update__link')}>
                        Update profile
                    </a>
                </div>
            </div>
        </div>
    );
};

export default UserInfo;
