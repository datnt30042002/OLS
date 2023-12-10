// From react and libs
import React from 'react';
import classNames from 'classnames/bind';
import { Link } from 'react-router-dom';

// Components
import styles from './ForgotPassword.module.scss';
import Image from '~/components/Image';
import OLSLogo from '~/assets/images/logo.svg';
import Button from '~/components/Button';
import config from '~/config';

const cx = classNames.bind(styles);

const ForgotPassword = () => {
    return (
        <div className={cx('wrapper')}>
            <div className={cx('grid')}>
                <div className={cx('row')}>
                    <div className={cx('col-12')}>
                        <div className={cx('forgot-password-wrap')}>
                            <div className={cx('forgot-password-header')}>
                                <Image src={OLSLogo} className={cx('forgot-password-header__logo')} />
                                <span className={cx('forgot-password-header__title')}>Forgot password</span>
                            </div>
                            <div className={cx('forgot-password-content')}>
                                <div className={cx('forgot-password-content__email')}>
                                    <label className={cx('forgot-password-content__email-title')}>
                                        You Email <span className={cx('forgot-password-content__required')}>*</span>
                                    </label>
                                    <input
                                        type="email"
                                        placeholder="Your Email"
                                        required
                                        className={cx('forgot-password-content__email-input')}
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
                                <div className={cx('forgot-password-content__forgot-password')}>
                                    <Link to={config.routes.resetpassword}>
                                        <Button
                                            large
                                            primary
                                            className={cx('forgot-password-content__forgot-password-button')}
                                        >
                                            <span
                                                className={cx('forgot-password-content__forgot-password-button__title')}
                                            >
                                                Verify
                                            </span>
                                        </Button>
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

export default ForgotPassword;
