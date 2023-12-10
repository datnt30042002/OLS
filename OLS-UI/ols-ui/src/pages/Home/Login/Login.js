// From react and libs
import React from 'react';
import classNames from 'classnames/bind';
import { Link } from 'react-router-dom';

// Components
import styles from './Login.module.scss';
import Image from '~/components/Image';
import OLSLogo from '~/assets/images/logo.svg';
import Button from '~/components/Button';
import config from '~/config';

const cx = classNames.bind(styles);

const Login = () => {
    return (
        <div className={cx('wrapper')}>
            <div className={cx('grid')}>
                <div className={cx('row')}>
                    <div className={cx('col-12')}>
                        <div className={cx('login-wrap')}>
                            <div className={cx('login-header')}>
                                <Image src={OLSLogo} className={cx('login-header__logo')} />
                                <span className={cx('login-header__title')}>Login to OLS</span>
                            </div>
                            <div className={cx('login-content')}>
                                <div className={cx('login-content__email')}>
                                    <label className={cx('login-content__email-title')}>
                                        You Email <span className={cx('login-content__required')}>*</span>
                                    </label>
                                    <input
                                        type="email"
                                        placeholder="Your Email"
                                        required
                                        className={cx('login-content__email-input')}
                                    />
                                </div>
                                <div className={cx('login-content__password')}>
                                    <label className={cx('login-content__password-title')}>
                                        Password <span className={cx('login-content__required')}>*</span>
                                    </label>
                                    <input
                                        type="password"
                                        placeholder="You Password"
                                        required
                                        className={cx('login-content__password-input')}
                                    />
                                </div>
                                {/* Xử lý logic ở đây */}
                                <div className={cx('login-content__forgot-password')}>
                                    <Link
                                        to={config.routes.forgotpassword}
                                        className={cx('login-content__forgot-password__title-link')}
                                    >
                                        Forgot password?
                                    </Link>
                                </div>
                                {/* Xử lý logic ở đây */}
                                <div className={cx('login-content__login')}>
                                    <Link to={'#'}>
                                        <Button large primary className={cx('login-content__login-button')}>
                                            <span className={cx('login-content__login-button__title')}>Login</span>
                                        </Button>
                                    </Link>
                                </div>
                                <div className={cx('login-content__register')}>
                                    Don't have an account?
                                    <Link to={config.routes.register} className={cx('login-content__register-link')}>
                                        Register
                                    </Link>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default Login;
