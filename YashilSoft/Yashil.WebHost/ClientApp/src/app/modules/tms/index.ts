import {CoursesPlanningDetailTabBasedComponent} from './courses-planning/courses-planning-detail-tab-based.component';

import {CoursesPlanningDetailComponent} from './courses-planning/courses-planning-detail.component';
import {CoursesPlanningListComponent} from './courses-planning/courses-planning-list.component';

import {CoursesPlanningStudentDetailComponent} from './courses-planning-student/courses-planning-student-detail.component';
import {CoursesPlanningStudentListComponent} from './courses-planning-student/courses-planning-student-list.component';

import {CourseDetailTabBasedComponent} from './course/course-detail-tab-based.component';

import {CourseDetailComponent} from './course/course-detail.component';
import {CourseListComponent} from './course/course-list.component';

import {RepresentationPersonDetailComponent} from './representation-person/representation-person-detail.component';
import {RepresentationPersonListComponent} from './representation-person/representation-person-list.component';

import {RepresentationDetailTabBasedComponent} from './representation/representation-detail-tab-based.component';

import {RepresentationDetailComponent} from './representation/representation-detail.component';
import {RepresentationListComponent} from './representation/representation-list.component';

import {CourseCategoryDetailComponent} from './course-category/course-category-detail.component';
import {CourseCategoryListComponent} from './course-category/course-category-list.component';

import {EducationalCenterDetailTabBasedComponent} from './educational-center/educational-center-detail-tab-based.component';

import {EducationalCenterDetailComponent} from './educational-center/educational-center-detail.component';
import {EducationalCenterListComponent} from './educational-center/educational-center-list.component';
import {Provider} from '@angular/core';
import {ContentEditorComponent} from './content-editor/content-editor.component';

export const COMPONENTS: Provider[] = [


    CoursesPlanningDetailTabBasedComponent,
    CoursesPlanningListComponent,

    CoursesPlanningDetailComponent,
    CoursesPlanningStudentListComponent,

    CoursesPlanningStudentDetailComponent,

    CourseDetailTabBasedComponent,
    CourseListComponent,

    CourseDetailComponent,
    RepresentationPersonListComponent,

    RepresentationPersonDetailComponent,

    RepresentationDetailTabBasedComponent,
    RepresentationListComponent,

    RepresentationDetailComponent,
    CourseCategoryListComponent,

    CourseCategoryDetailComponent,

    EducationalCenterDetailTabBasedComponent,
    EducationalCenterListComponent,

    EducationalCenterDetailComponent,
    ContentEditorComponent
];
