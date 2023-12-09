// from react and libs
import React from 'react';
import axios from 'axios';
import classNames from 'classnames/bind';
import { useState, useEffect } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faUser } from '@fortawesome/free-regular-svg-icons';

// components
import styles from './Settings.module.scss';
import Image from '~/components/Image';
import Button from '~/components/Button';
import { Link } from 'react-router-dom';

const cx = classNames.bind(styles);

const Settings = () => {
    return (
        <main className={cx('wrapper')}>
            {/* Grid */}
            <div className={cx('grid')}>
                {/* Row */}
                <div className={cx('row')}>
                    {/* Col */}
                    <div className={cx('col-3')}>
                        <div className={cx('settings__side-bar')}>
                            <h1 className={cx('settings__side-bar__heading')}>Settings</h1>
                            <div className={cx('settings__select')}>
                                <div className={cx('settings__option', 'selected')}>
                                    {/* Link - ul li */}
                                    <Link href="#" className={cx('settings__option-item')}>
                                        <FontAwesomeIcon icon={faUser} className={cx('settings__option-item-icon')} />
                                        <span className={cx('settings__option-item-title')}>Account</span>
                                    </Link>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div className={cx('col-9')}>
                        <div className={cx('settings__content')}>
                            <h1 className={cx('settings__content-heading')}>Account</h1>
                            <div className={cx('settings__user-info')}>
                                <div className={cx('user-info__avatar-wrap')}>
                                    {/* Select image from file when click to image */}
                                    <Image
                                        src={'https://avatars.githubusercontent.com/u/108357953?v=4'}
                                        alt="avatar"
                                        className={cx('user-info__avatar')}
                                    />
                                </div>
                                <div className={cx('user-info__name-wrap')}>
                                    <p className={cx('user-info__title')}>Full name</p>
                                    <input type="text" value={'user name'} className={cx('user-info__name-input')} />
                                </div>
                                <div className={cx('user-info__email-wrap')}>
                                    <p className={cx('user-info__title')}>Email</p>
                                    <input type="text" value={'email'} className={cx('user-info__email-input')} />
                                </div>
                                <div className={cx('user-info__phone-wrap')}>
                                    <p className={cx('user-info__title')}>Phone number</p>
                                    <input type="text" value={'phone'} className={cx('user-info__phone-input')} />
                                </div>
                                <div className={cx('user-info__password-wrap')}>
                                    <p className={cx('user-info__title')}>Password</p>
                                    <input
                                        type="password"
                                        value={'password'}
                                        className={cx('user-info__password-input')}
                                    />
                                </div>
                            </div>
                            <div className={cx('settings-save')}>
                                <Button outline small className={cx('settings-save__btn')}>
                                    Save
                                </Button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </main>
    );
};

export default Settings;
