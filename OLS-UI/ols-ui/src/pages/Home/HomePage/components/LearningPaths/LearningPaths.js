// from react and libs
import React from 'react';
import axios from 'axios';
import classNames from 'classnames/bind';
import { useState, useEffect } from 'react';

// components
import styles from './LearningPaths.module.scss';
import Image from '~/components/Image';

const cx = classNames.bind(styles);

const LearningPaths = () => {
    const [learningPaths, setLearningPaths] = useState([]);

    useEffect(() => {
        getDataFromApi();
    }, []);

    const getDataFromApi = async () => {
        try {
            const response = await axios.get('https://localhost:7158/getAllLearningPaths_HomePage');

            if (!response.status === 200) {
                throw new Error('Network is not ok. Cannot connect to API.');
            }

            setLearningPaths(response.data);
        } catch (error) {
            throw new Error(error);
        }
    };

    return (
        <div className={cx('wrapper')}>
            {/* Grid */}
            <div className={cx('grid')}>
                <h1 className={cx('learning-path-heading')}>Explore Learning Paths</h1>
                {/* Row */}
                <div className={cx('row')}>
                    {/* Col */}
                    {learningPaths.map((learningPath) => (
                        <div key={learningPath.learningPathId} className={cx('col-3')}>
                            <div className={cx('learning-path-item')}>
                                <a href="#" className={cx('learning-path-item__link')}>
                                    <div className={cx('learning-path-item__image')}>
                                        <Image
                                            src={learningPath.image}
                                            alt={learningPath.learningPathName}
                                            className={cx('learning-path-image')}
                                        />
                                    </div>
                                    <div className={cx('learning-path-item__content')}>
                                        <span className={cx('learning-path-item__content-name')}>
                                            {learningPath.learningPathName}
                                        </span>
                                        <span className={cx('learning-path-item__content-description')}>
                                            {learningPath.description}
                                        </span>
                                        <span className={cx('learning-path-item__content-courses-amount')}>
                                            100 courses
                                        </span>
                                    </div>
                                </a>
                            </div>
                        </div>
                    ))}
                </div>
            </div>
        </div>
    );
};

export default LearningPaths;
