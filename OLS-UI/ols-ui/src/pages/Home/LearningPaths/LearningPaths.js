// from react and libs
import React from 'react';
import axios from 'axios';
import classNames from 'classnames/bind';
import { useState, useEffect } from 'react';

// components
import styles from './LearningPaths.module.scss';
import Image from '~/components/Image';

// quy ước viết tắt của classNames
const cx = classNames.bind(styles);

const LearningPaths = () => {
    const [learningPaths, setLearningPaths] = useState([]);

    useEffect(() => {
        getDataFromApi();
    }, []);

    const getDataFromApi = async () => {
        try {
            const response = await axios.get('https://localhost:7158/getAllLearningPaths_LearningPaths');

            if (!response.status === 200) {
                throw new Error('Network is not ok. Cannot connect to API.');
            }

            setLearningPaths(response.data);
        } catch (error) {
            throw new Error(error);
        }
    };

    return (
        <main>
            {/* Grid */}
            <div className={cx('grid')}>
                {/* Row */}
                <div className={cx('row')}>
                    {/* Col */}
                    <div className={cx('col-12')}>
                        <div className={cx('learningPath-header')}>
                            <div className={cx('learningPath-header__left-title')}>
                                <h1>Project Coordinator</h1>
                                <span>ENTRY LEVEL</span>
                            </div>

                            <div className={cx('learningPath-header__content')}>
                                <p>
                                    Project Coordinators organize meetings, resources, equipment, and information for a
                                    team, with the goal of improving efficiency and streamlining workflows and
                                    processes.
                                </p>
                            </div>

                            <div className={cx('learningPath-header__right-title')}>
                                <span>Key Skills to Learn</span>
                                <span>Project management, Excel, Scheduling</span>
                            </div>
                        </div>
                    </div>
                </div>

                {/* Row */}
                <div className={cx('row')}>
                    {/* Col */}
                    <div className={cx('col-12')}>
                        <div className={cx('wrap')}>
                            <div className={cx('col-2-4')}>
                                <img src="https://avatars.githubusercontent.com/u/108357953?v=4" alt="" />
                            </div>

                            <div className={cx('col-2-8')}>
                                <div className={cx('test-2')}></div>
                            </div>
                        </div>
                    </div>
                </div>

                {/* Row */}
                {/* <div className={cx('row')}>
                    <div className={cx('col-12')}>
                        <div className={cx('learningPath-footer')}>
                            <div className={cx('learningPath-footer__degree')}>
                                <div className={cx('learningPath-footer__degree-img')}>degree img</div>
                                <div className={cx('learningPath-footer__degree-content')}>degree content</div>
                            </div>
                        </div>
                    </div>
                </div> */}
            </div>
        </main>
    );
};

export default LearningPaths;
