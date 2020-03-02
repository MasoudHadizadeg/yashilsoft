import {CoursesPlanningDetailTabBasedComponent} from './courses-planning/courses-planning-detail-tab-based.component';

import {CoursesPlanningDetailComponent} from './courses-planning/courses-planning-detail.component';

import {CoursesPlanningStudentDetailComponent} from './courses-planning-student/courses-planning-student-detail.component';

import {CourseDetailTabBasedComponent} from './course/course-detail-tab-based.component';

import {CourseDetailComponent} from './course/course-detail.component';

import {RepresentationPersonDetailComponent} from './representation-person/representation-person-detail.component';

import {RepresentationDetailTabBasedComponent} from './representation/representation-detail-tab-based.component';

import {RepresentationDetailComponent} from './representation/representation-detail.component';

import {CourseCategoryDetailComponent} from './course-category/course-category-detail.component';

import {EducationalCenterDetailTabBasedComponent} from './educational-center/educational-center-detail-tab-based.component';

import {EducationalCenterDetailComponent} from './educational-center/educational-center-detail.component';
import {Provider} from '@angular/core';
import {ContentEditorComponent} from './content-editor/content-editor.component';

export const ENTRYCOMPONENTS: Provider[] = [
    CoursesPlanningDetailTabBasedComponent,
    CoursesPlanningDetailComponent,
    CoursesPlanningStudentDetailComponent,
    CourseDetailTabBasedComponent,
    CourseDetailComponent,
    RepresentationPersonDetailComponent,
    RepresentationDetailTabBasedComponent,
    RepresentationDetailComponent,
    CourseCategoryDetailComponent,
    EducationalCenterDetailTabBasedComponent,
    EducationalCenterDetailComponent,
    ContentEditorComponent
];
