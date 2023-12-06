// from react and libs
import React from 'react';
import classNames from 'classnames/bind';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import {
    faFacebook,
    faInstagramSquare,
    faTwitterSquare,
    faYoutubeSquare,
    faLinkedin,
} from '@fortawesome/free-brands-svg-icons';

// components
import styles from './Footer.module.scss';
import Image from '~/components/Image';
import GooglePlay from '~/assets/images/apps/google-play.png';
import AppStore from '~/assets/images/apps/app-store.png';
import Certified from '~/assets/images/apps/certified.png';

const cx = classNames.bind(styles);

const Footer = () => {
    return (
        <footer className={cx('wrapper')}>
            <div className={cx('grid')}>
                {/* Row */}
                {/* Content */}
                <div className={cx('row')}>
                    {/* Col */}
                    <div className={cx('col-3')}>
                        <div className={cx('footer-content')}>
                            <h1 className={cx('footer-heading')}>Coursera</h1>
                            <ul className={cx('footer-list')}>
                                <li className={cx('footer-item')}>
                                    <a href="#" className={cx('footer-item__link')}>
                                        About
                                    </a>
                                </li>
                                <li className={cx('footer-item')}>
                                    <a href="#" className={cx('footer-item__link')}>
                                        What We Offer
                                    </a>
                                </li>
                                <li className={cx('footer-item')}>
                                    <a href="#" className={cx('footer-item__link')}>
                                        Leadership
                                    </a>
                                </li>
                                <li className={cx('footer-item')}>
                                    <a href="#" className={cx('footer-item__link')}>
                                        Careers
                                    </a>
                                </li>
                                <li className={cx('footer-item')}>
                                    <a href="#" className={cx('footer-item__link')}>
                                        Catalog
                                    </a>
                                </li>
                                <li className={cx('footer-item')}>
                                    <a href="#" className={cx('footer-item__link')}>
                                        Coursera Plus
                                    </a>
                                </li>
                                <li className={cx('footer-item')}>
                                    <a href="#" className={cx('footer-item__link')}>
                                        Professional Certificates
                                    </a>
                                </li>
                                <li className={cx('footer-item')}>
                                    <a href="#" className={cx('footer-item__link')}>
                                        MasterTrack® Certificates
                                    </a>
                                </li>
                                <li className={cx('footer-item')}>
                                    <a href="#" className={cx('footer-item__link')}>
                                        Degrees
                                    </a>
                                </li>
                                <li className={cx('footer-item')}>
                                    <a href="#" className={cx('footer-item__link')}>
                                        For Enterprise
                                    </a>
                                </li>
                                <li className={cx('footer-item')}>
                                    <a href="#" className={cx('footer-item__link')}>
                                        Coronavirus Response
                                    </a>
                                </li>
                            </ul>
                        </div>
                    </div>

                    {/* Col */}
                    <div className={cx('col-3')}>
                        <div className={cx('footer-content')}>
                            <h1 className={cx('footer-heading')}>Community</h1>
                            <ul className={cx('footer-list')}>
                                <li className={cx('footer-item')}>
                                    <a href="#" className={cx('footer-item__link')}>
                                        Learners
                                    </a>
                                </li>
                                <li className={cx('footer-item')}>
                                    <a href="#" className={cx('footer-item__link')}>
                                        Partners
                                    </a>
                                </li>
                                <li className={cx('footer-item')}>
                                    <a href="#" className={cx('footer-item__link')}>
                                        Beta Testers
                                    </a>
                                </li>
                                <li className={cx('footer-item')}>
                                    <a href="#" className={cx('footer-item__link')}>
                                        Translators
                                    </a>
                                </li>
                                <li className={cx('footer-item')}>
                                    <a href="#" className={cx('footer-item__link')}>
                                        Blog
                                    </a>
                                </li>
                                <li className={cx('footer-item')}>
                                    <a href="#" className={cx('footer-item__link')}>
                                        Tech Blog
                                    </a>
                                </li>
                                <li className={cx('footer-item')}>
                                    <a href="#" className={cx('footer-item__link')}>
                                        Teaching Center
                                    </a>
                                </li>
                            </ul>
                        </div>
                    </div>

                    {/* Col */}
                    <div className={cx('col-3')}>
                        <div className={cx('footer-content')}>
                            <h1 className={cx('footer-heading')}>More</h1>
                            <ul className={cx('footer-list')}>
                                <li className={cx('footer-item')}>
                                    <a href="#" className={cx('footer-item__link')}>
                                        Press
                                    </a>
                                </li>
                                <li className={cx('footer-item')}>
                                    <a href="#" className={cx('footer-item__link')}>
                                        Investors
                                    </a>
                                </li>
                                <li className={cx('footer-item')}>
                                    <a href="#" className={cx('footer-item__link')}>
                                        Terms
                                    </a>
                                </li>
                                <li className={cx('footer-item')}>
                                    <a href="#" className={cx('footer-item__link')}>
                                        Privacy
                                    </a>
                                </li>
                                <li className={cx('footer-item')}>
                                    <a href="#" className={cx('footer-item__link')}>
                                        Help
                                    </a>
                                </li>
                                <li className={cx('footer-item')}>
                                    <a href="#" className={cx('footer-item__link')}>
                                        Accessibility
                                    </a>
                                </li>
                                <li className={cx('footer-item')}>
                                    <a href="#" className={cx('footer-item__link')}>
                                        Affiliates
                                    </a>
                                </li>
                                <li className={cx('footer-item')}>
                                    <a href="#" className={cx('footer-item__link')}>
                                        Modern Slavery Statement
                                    </a>
                                </li>
                                <li className={cx('footer-item')}>
                                    <a href="#" className={cx('footer-item__link')}>
                                        Manage Cookie Preferences
                                    </a>
                                </li>
                            </ul>
                        </div>
                    </div>

                    {/* Col */}
                    <div className={cx('col-3')}>
                        <div className={cx('footer-content')}>
                            <h1 className={cx('footer-heading')}>Mobile App</h1>
                            <div className={cx('footer-download')}>
                                <div className={cx('footer-download__apps')}>
                                    <a href="#" className={cx('footer-download__google-play')}>
                                        <Image src={GooglePlay} />
                                    </a>
                                    <a href="#" className={cx('footer-download__app-store')}>
                                        <Image src={AppStore} />
                                    </a>
                                </div>
                                <a href="#" className={cx('footer-download__certified')}>
                                    <Image src={Certified} />
                                </a>
                            </div>
                        </div>
                    </div>
                </div>

                {/* Row */}
                {/* Copyright */}
                <div className={cx('row')}>
                    {/* Col */}
                    <div className={cx('col-12')}>
                        <div className={cx('copy-right')}>
                            <div className={cx('copy-right__heading')}>
                                <p className={cx('copy-right__heading-text')}>
                                    © 2023 Coursera Inc. All rights reserved.
                                </p>
                            </div>
                            <div className={cx('brand-icon')}>
                                <a href="#" className={cx('brand-icon__link')}>
                                    <FontAwesomeIcon className={cx('brand-icon__facebook')} icon={faFacebook} />
                                </a>
                                <a href="#" className={cx('brand-icon__link')}>
                                    <FontAwesomeIcon className={cx('brand-icon__linkedin')} icon={faLinkedin} />
                                </a>
                                <a href="#" className={cx('brand-icon__link')}>
                                    <FontAwesomeIcon className={cx('brand-icon__twitter')} icon={faTwitterSquare} />
                                </a>
                                <a href="#" className={cx('brand-icon__link')}>
                                    <FontAwesomeIcon className={cx('brand-icon__youtube')} icon={faYoutubeSquare} />
                                </a>
                                <a href="#" className={cx('brand-icon__link')}>
                                    <FontAwesomeIcon className={cx('brand-icon__instagram')} icon={faInstagramSquare} />
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </footer>
    );
};

export default Footer;
