// From react and libs
import React from 'react';
import classNames from 'classnames/bind';
import { Link } from 'react-router-dom';

// Components
import styles from './Register.module.scss';
import Image from '~/components/Image';
import OLSLogo from '~/assets/images/logo.svg';
import Button from '~/components/Button';
import config from '~/config';

const cx = classNames.bind(styles);

const Register = () => {
    return (
        <div className={cx('wrapper')}>
            <div className={cx('grid')}>
                <div className={cx('row')}>
                    <div className={cx('col-12')}>
                        <div className={cx('register-wrap')}>
                            <div className={cx('register-header')}>
                                <Image src={OLSLogo} className={cx('register-header__logo')} />
                                <span className={cx('register-header__title')}>Register an account OLS</span>
                            </div>
                            <div className={cx('register-content')}>
                                <div className={cx('register-content__full-name')}>
                                    <label className={cx('register-content__full-name-title')}>
                                        Full Name <span className={cx('register-content__required')}>*</span>
                                    </label>
                                    <input
                                        type="text"
                                        placeholder="Your Full Name"
                                        required
                                        className={cx('register-content__full-name-input')}
                                    />
                                </div>
                                <div className={cx('register-content__email')}>
                                    <label className={cx('register-content__email-title')}>
                                        You Email <span className={cx('register-content__required')}>*</span>
                                    </label>
                                    <input
                                        type="email"
                                        placeholder="Your Email"
                                        required
                                        className={cx('register-content__email-input')}
                                    />
                                </div>
                                <div className={cx('register-content__password')}>
                                    <label className={cx('register-content__password-title')}>
                                        Password <span className={cx('register-content__required')}>*</span>
                                    </label>
                                    <input
                                        type="password"
                                        placeholder="You Password"
                                        required
                                        className={cx('register-content__password-input')}
                                    />
                                </div>
                                {/* Xử lý logic ở đây */}
                                <div className={cx('register-content__verify-email')}>
                                    <label className={cx('register-content__verify-email-title')}>
                                        Verify email <span className={cx('register-content__required')}>*</span>
                                    </label>
                                    <div className={cx('register-content__verify-email-input-wrap')}>
                                        <input
                                            type="number"
                                            placeholder="Verify code"
                                            required
                                            className={cx('register-content__verify-email-input')}
                                        />
                                        <Button outline small className={cx('register-content__verify-email-button')}>
                                            Send code
                                        </Button>
                                    </div>
                                </div>
                                {/* Xử lý logic ở đây */}
                                <div className={cx('register-content__login')}>
                                    <Link to={'#'}>
                                        <Button large primary className={cx('register-content__register-button')}>
                                            <span className={cx('register-content__register-button__title')}>
                                                Register
                                            </span>
                                        </Button>
                                    </Link>
                                </div>
                                <div className={cx('register-content__register')}>
                                    Have an account?
                                    <Link to={config.routes.login} className={cx('register-content__register-link')}>
                                        Login
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

export default Register;
